# Eve.Mvc

EVE.Mvc is a utility library for ASP.NET MVC

It contains:
* Plugin system that does not require separate static file deployment
* Utilities for using EmbeddedFileSystem to serve static content and html as ActionResult
* A View Engine that uses static embedded html as markup and a separate c# view class for markup (DOM) manipulation.

This sample application will use a scenario where an existing application needs to be extended with a landing page. The landing page has a style sheet and a set of static resources which are alien to the original application's resources. Thus it is a requirement to achieve maximum separation. The landing page is provided by StartBootstrap.

The sample app will show how to create a plugin (EVE.Mvc.Samples.Embedded) via EVE.Mvc that includes only 1 dll and it is able to show the landing page similar to a static html.

The EVE.Mvc.Samples.ViewEngine plugin project shows the same landing page, but this time using the EmbeddedViewEngine. Actual MVC views are used, which have a masterpgae and are using partial views for specific parts of the page.

Build the sample applicaiton for tutorials.

[Sample App Live](http://evemvc.azurewebsites.net/)
