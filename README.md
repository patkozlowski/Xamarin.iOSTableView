# Xamarin.iOSTableView

Xamarin.iOS 10 project to how to ingest information into a UITableView.

Ingested data two ways: JSON File, and using Parse Server (You need to configure your own Parse Server).

Be sure to re-add Parse, SDWebImage for Xamarin.iOS, Newtonsoft.JSON, & External Maps Plugin if the solution doesn't restore the packages successfully.

When selecting a UITableView Cell, this will navigate to that location using the External Maps plugin.

Use XCode 8 Interface builder if you need to tweak the GUI.

Using Parse Server, create your own Parse Server instance using https://github.com/ParsePlatform/parse-server-example (I used Heroku, and it's free in Dev environments). Create a "Museum" class and create "Name", "Address", "Latitude", and "Longitude" columns, and input row information for each one. See AppDelegate.cs.
