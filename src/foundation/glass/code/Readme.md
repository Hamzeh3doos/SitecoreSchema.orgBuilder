#Glass Installer

Glass.Mapper V4.
Moves default Glass bootstrap process to IoC installer.
Allows glass services, ISitecoreService and ISitecoreContext, to be used in all SiteDeck.IoC containers for dependency injection (controllers, pipelines, event handlers, etc).
And allows other IoC services to be used in Glass class constructors

##Services Offered
Adds Glass services for dependency injection to all SiteDeck.IoC supported code locations:
* ISitecoreService
* ISitecoreContext