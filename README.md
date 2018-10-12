# Ministry.TestSupport #
The aim of the Ministry Test Support Libraries is to provide a suite of Fakes, Mocks and assertion classes that make the process of testing easier. This is not exclusively for unit testing either, the libraries also support console automation testing.

The Ministry.TestSupport code is split into separate libraries sharing the same namespaces. The primary library, Ministry.TestSupport deals directly with any core functionality without any mocking consideration whilst the secondary libraries add features that require a mocking consideration. Initially, the library Ministry.TestingSupport.Moq provides functionality requiring mocking consideration for Moq. If you're interested in similar functionality for your mocking framework of choice please join the project - The code has been built with extensibility of other mocking frameworks in mind. I would like to offer Ministry.TestingSupport.Rhino and Ministry.TestingSupport.NSubstitute at some point in the future.

##ISupportFactory##
Most of this functionality is ether accessed via base classes or via an implementation of ISupportFactory.

The ISupportFactory interface exposes the accessible instances for a given test usage implementation at the lowest possible level.  The base interface looks like this...

	public interface ISupportFactory
	{
		IAssertionFramework AssertionFramework { get; }
	}

Implementations are available in both NUnit and MSTest flavours, providing an implementation of the AssertionFramework for each particular unit testing framework.

###With Mocks###

The higher level libraries expose a more detailed interface called ISupportFactoryWithMocks that allows instantiation of other dependent testing elements...

	public interface ISupportFactoryWithMocks : ISupportFactory
	{
		MvcRouteAsserter RouteAssert { get; }
	}

The implementations of the interface also inherit from their lower level counterparts. This allows a clean separation between elements that require a mocking context and those that don't.

The following functionality is offered by the libraries...

##Abstract Testing Frameworks##

Although only several key assertions are supported (feel free to join the project and add some more of your own!), all of the key functionality within the testing support libraries is accessed by an implementation of the IAssertionFramework interface...

	public interface IAssertionFramework
	{
		void IsNull<T>(T anObject);
		void IsNull<T>(T anObject, string message);

		void IsNotNull<T>(T anObject);
		void IsNotNull<T>(T anObject, string message);

		void IsTrue(bool condition);
		void IsTrue(bool condition, string message);
		void IsTrue(bool condition, string message, params object[] args);

		void IsFalse(bool condition);
		void IsFalse(bool condition, string message);
		void IsFalse(bool condition, string message, params object[] args);

		void AreEqual<T>(T expected, T actual);
		void AreEqual<T>(T expected, T actual, string message);

		void AreCaseInsensitiveEqual<T>(T expected, T actual);
		void AreCaseInsensitiveEqual<T>(T expected, T actual, string message);
	}

The IAssertionFramework interface allows the actual testing framework used to be abstracted out until the point at which the actual test is written. At the time of writing there are two implementations included for this interface, one for NUnit and one for MSTest (located in the NUnit and MSTest namespaces respectively). Support for other frameworks may be added later, but it is a goal of the project to maintain feature parity for both NUnit and MSTest throughout and to minimise code duplication. Abstracting the framework enables this goal.

The assertion framework implementation can either be instantiated directly or via an implementation of the ISupportFactory interface.

###New Assertions###
The assertion abstraction also introduces the 'AreCaseInsensitiveEqual' assertion, which allows you to assert that two objects are identical by their string representation regardless of case. This makes writing tests for things like MVC Routing a lot smaller.

##Console Automation Testing##
Console automation testing is a relatively simple concept. Similar to UI automation testing but the only thing to test is the execution of a command and what happens as a result. This usually involves interrogating the screen output.

Console automation is achieved by way of inheriting from the ConsoleTestBase class in Ministry.TestSupport. When inheriting you must override the TestSupportFactory property and the FixtureSetUp method, ensuring that it is called at the beginning of the fixture or test.

###Differing Frameworks###
Managing this process in the different frameworks is slightly different due to execution orders. To make things easier there is an MSTestConsoleTestBase and NUnitConsoleTestBase class in the respective framework namespaces to make the process easier.

###Creating an Automated Test###
This simply involves creating a test class that inherits from the base class for the framework you intend to use. This will then give you access to all of the properties and methods to manipulate the underlying application (specified by overriding the AppName property). Sample code is given for each test in the source code under 'tests'.

NUnit...
	[TestFixture]
	public class ConsoleTestClass : NUnitConsoleTestBase
	{
		[Test]
		public void TestTrue()
		{
			AssertApplicationRunsSuccessfully();
			Assert.IsTrue(true);
		}

		[Test]
		public void TestPrintsHello()
		{
			AssertApplicationRunsSuccessfully();
			AssertConsoleOutputContains("Hello");
			AssertConsoleOutputDoesNotContain("Goodbye");
		}

		protected override string AppFileName
		{
			get { return @"C:\Development\Projects\TestSupport\tests\printhello.bat"; }
		}
	}

MSTest...

	[TestClass]
	public class ConsoleTestClass : MSTestConsoleTestBase
	{
		[TestMethod]
		public void TestTrue()
		{
			AssertApplicationRunsSuccessfully();
			Assert.IsTrue(true);
		}

		[TestMethod]
		public void TestPrintsHello()
		{
			AssertApplicationRunsSuccessfully();
			AssertConsoleOutputContains("Hello");
			AssertConsoleOutputDoesNotContain("Goodbye");
		}

		protected override string AppFileName
		{
			get { return @"C:\Development\Projects\TestSupport\tests\printhello.bat"; }
		}
	}

###Key Properties & Methods###
The following properties & methods are key...

* **StartConsoleApplication **- Starts up the application with the specified arguments.
* (Setup & TearDown methods) - Implemented largely by the framework specific types these wrap the application and unwrap it.
* **TestStringBuilder **- Contains the output so you can interrogate it.
* **StandardOutput **- The output, redirected to a TextWriter
* **TestConsole **- The string writer
* **AppFileName **- The name of the app or script to execute (must be overridden in the test)
* **TestSupportFactory **- The Factory to determine framework abstraction (overridden in the framework specific base classes).

###Custom Assertions###
The base class also provides some custom assertions to make the process even easier...

* **AssertApplicationRunsSuccessfully **- Checks that the app runs up and exits with no error code.
* **AssertApplicationReturnsExitCode **- Checks that the app returns a specified exit code.
* **AssertConsoleOutputContains **- Checks the output for a string.
* **AssertConsoleOutputDoesNotContain **- Checks that a string is not present.

##Mocking HttpContext##
Mocking HttpContext is a persistent problem for web developers. Ministry.TestSupport.Moq offers a very simple mocking solution for HttpContext. It's fairly limited but should suffice in 80% of cases.

###MockHttpContext###
The library contains objects for MockHttpContext, MockHttpRequest and MockHttpResponse. These are managed through various optional constructors.

The classes inherit from Mock<??> directly enabling to to adapt the retained objects to setup any specific additional mocking and verification that you need.

The returned Mock objects contain collections and mthods to mock and stub common elements of context. Please raise an issue if you find a test need that this doesn't cover, as I'd like to expand this to cover as much as possible.

The MockHttpContext object also has an 'ApplyTo' method so you can add it to a controller when testing MVC controllers. For example...

	[Test]
	public override void TestController()
	{
	   // Create a default context with a default request and response
	   var mockContext = new MockHttpContext();

	   // Create the controller to test
	   var objUt = new HomeController();

	   // Apply the context.
	   mockContext.ApplyTo(objUt);
	}

##Testing Routes in ASP.Net MVC##
Ministry.TestingSupport offers a simple solution to make route testing, for both incoming and outgoing routes, really clean and simple. This is achieved through the use of two classes. The primary class is the 'MvcRouteAsserter', an instance of which is provided by the ISupportFactoryWithMocks implementation for your chosen testing framework. Moq is required for this to work at the moment but if you would like this for your chosen mocking framework feel free to join the project and add support or raise an issue and I'll add support when I can.

###The MvcRouteAsserter###
This is a straightforward class which simply takes an instance of IAssertionFramework and then wraps up a suite of assertions you would normally perform to test a route into one simple assertion. Assertions provided include...

* **AssertRouteIsValid**
* **AssertRouteIsInvalid**
* **AssertOutgoingRouteUrlGeneration**

###RouteTestBase###
Creating a route test is very straightforward. By inheriting from TouteTestBase, you get shorthand local assertion methods that call through to the MvcRouteAsserter. There are some key things to do to set up a route test for your application, as follows...

1. Override the 'TestSupportFactory' property with the implementation for your testing framework of choice with mocks.
2. Override 'SetupFixture()' and ensure it's decorated to run at the beginning of the fixture or test class. It should read something like this and ensure that the Routes property is populated from the application...

	[TestFixtureSetUp]
	public override void SetUpFixture()
	{
	   Routes = new RouteCollection();
	   MvcApplication app = new MvcApplication();
	   app.RegisterAllRoutes(Routes);
	}

###Creating your own base class###
It makes a lot of sense to create your own base class for route tests, inheriting from RouteTestBase. Here's my base class for the Ministry website...

	[TestFixture]
	public class MinistryotechRouteTestBase : RouteTestBase
	{
		#region | Setup & TearDown |

		/// <summary>
		/// Sets up the test fixture.
		/// </summary>
		[TestFixtureSetUp]
		public override void SetUpFixture()
		{
			Routes = new RouteCollection();
			MvcApplication app = new MvcApplication();
			app.RegisterAllRoutes(Routes);
		}

		#endregion

		/// <summary>
		/// Gets the test support factory.
		/// </summary>
		protected override ISupportFactory TestSupportFactory
		{
			get { return new NUnitSupportFactory(); }
		}
	}

This then makes the test classes themselves really clean and readable. Here's my own NUnit tests...

	[TestFixture]
	public class BlogRouteTests : MinistryotechRouteTestBase
	{
		[Test]
		[TestCase("~/blog", "index")]
		[TestCase("~/blog/", "index")]
		[TestCase("~/blog/page", "showpage")]
		[TestCase("~/blog/page/", "showpage")]
		[TestCase("~/blog/page1", "showpage")]
		[TestCase("~/blog/page2/", "showpage")]
		[TestCase("~/blog/page87", "showpage")]
		[TestCase("~/blog/feed.rss", "feed")]
		public void TestViewPageBlogRoutes(string url, string action)
		{
			AssertRouteIsValid(url, "list", action, "blog", HttpVerbs.Get);
		}

		[Test]
		public void TestViewPageBlogVariables()
		{
			AssertRouteIsValid("~/blog/page1", "list", "showpage", "blog", HttpVerbs.Get, new { page = 1 });
			AssertRouteIsValid("~/blog/page", "list", "showpage", "blog", HttpVerbs.Get, new { page = 1 });
			AssertRouteIsValid("~/blog/page4", "list", "showpage", "blog", HttpVerbs.Get, new { page = 4 });
		}

		[Test]
		[TestCase("/blog", "index")]
		[TestCase("/blog/page", "showpage")]
		public void TestMainBlogAreaRoutesUrlGeneration(string url, string action)
		{
			AssertOutgoingRouteUrlGeneration(url, "list", action, null, new { area = "blog" });
		}

		[Test]
		public void TestBlogAreaPagedRoutesUrlGeneration()
		{
			AssertOutgoingRouteUrlGeneration("/blog/page3", "list", "showpage", null, new { page = 3, area = "blog" });
		}

		[Test]
		public void TestInvalidViewPageBlogVariables()
		{
			// These will fall back to the hideous Umbraco catch-all
			AssertRouteIsValid("~/blog/pagedinky", "blog", "pagedinky");
			AssertRouteIsValid("~/blog/pageCabbage", "blog", "pageCabbage");
		}

		[Test]
		[TestCase("~/blog/eating-fish", "eating-fish")]
		[TestCase("~/blog/support/", "support")]
		public void TestBlogItemRoutesUseTheUmbracoRoutes(string url, string action)
		{
			AssertRouteIsValid(url, "blog", action);
		}

		[Test]
		[TestCase("~/i-dont-exist/things1/things2/things3")]
		public void TestBadRoutesDontWork(string url)
		{
			AssertRouteIsInvalid(url);
		}

		[Test]
		[TestCase("/blog/eating-fish", "eating-fish")]
		[TestCase("/blog/support", "support")]
		public void TestBlogItemRoutesUrlGeneration(string url, string action)
		{
			AssertOutgoingRouteUrlGeneration(url, "blog", action);
		}
	}

## The Ministry of Technology Open Source Products ##
Welcome to The Ministry of Technology open source products. All open source Ministry of Technology products are distributed under the MIT License for maximum re-usability. Details on more of our products and services can be found on our website at http://www.minotech.co.uk

Our other open source repositories can be found here...

* [https://github.com/ministryotech](https://github.com/ministryotech)
* [https://github.com/tiefling](https://github.com/tiefling)

Most of our content is stored on both Github and Bitbucket.

### Where can I get it? ###
You can download the package for this project from any of the following package managers...

- **NUGET (Primary Library)** - [https://nuget.org/packages/Ministry.TestSupport](https://nuget.org/packages/Ministry.TestSupport)
- **NUGET (Moq Support)** - [https://nuget.org/packages/Ministry.TestSupport.Moq](https://nuget.org/packages/Ministry.TestSupport.Moq)

### Contribution guidelines ###
If you would like to contribute to the project, please contact me.

The source code can be used in a simple text editor or within Visual Studio using NodeJS Tools for Visual Studio.

### Who do I talk to? ###
* Keith Jackson - keith@minotech.co.uk
