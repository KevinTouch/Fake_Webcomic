# FakeWebcomic

## Project Description

Fake Webcomics are comics published on a website or mobile app. Read comics like you would on a newspaper but instead online! Authors can create new pages, modify/delete old ones, and update the About page for webcomics they own, as well as create new webcomics and delete their old ones. All users can view the comics, navigating either through an Archive page (sorted by number and title) or by using the links on each comic page that will take them to the next page, previous page, first page, last page, and even a random page.

## Technologies Used

Back-End Tech:
* Azure App Service
* Azure SQL
* C#
* .NET Core
* ASP.NET Core
* Docker
* Github
* Github Actions (CI/CD)
* Entity Framework Core for ORM
* Microsoft SQL Server
* MVC
* xUnit Testing

Front-End Tech:
* Angular
* HTML, CSS, JS
* Bootstrap
* Postman

## Features

Currently Implemented:
* Any user can view all webcomics, navigating between them via the main archive.
* Any user can view all pages in a webcomic, navigating between them via links to the next, previous, first, latest, and random pages, as well as the About page and the Archive page (which also contains links to each page).
* Webcomic authors can sign in, letting them view the webcomcis they own, as well as delete them or create new ones.
* Any user can view the main about page, which describes the FakeWebcomic project and lists the total number of webcomics and pages stored on the site.

To-do list:
* Links to the forms for modifying, deleting, and adding pages to a webcomic should be added to the Author Home Page.
* The list of owned webcomics on the Author Home Page should include links to both those webcomics and their comic pages.
* Comic images not loading properly; models should be fixed such that HTML can properly read them.

## Getting Started
   
git clone https://github.com/KevinTouch/Fake_Webcomic.git
dotnet run ~/Fake_Webcomic/Storage/FakeWebcomic.Storage/
dotnet run ~/Fake_Webcomic/FakeWebcomic.Client/
http://localhost:6001

## Usage

Once on the site, usage is fairly self-explanatory. The starting page is the main archive, with links to all webcomics on the site. The navbar has links to the main About page, back to the main archive, and Author Sign-In (if not already signed in) or the Author Home Page and Sign-Out (if already signed in).

Clicking on a link to a webcomic will take you to its latest page (if it has any pages yet) or its About page (if it doesn't).

While within a webcomic, an additional navbar is displayed with links to that webcomic, its about page, and its archive.

Comic pages also have links above and below the comic image to the first page, previous page, archive, a random page, next page, and latest page. The first page lacks links to previous and first pages (they wouldbe unnecessary), and similarly, the latest page lacks links to the next and latest page.

The Author Home Page contains a list of all webcomcis owned by that author on the left side, with the option to delete that webcomic below its name. To the right is a form for creating a new webcomic, complete with submission button ("Create New Webcomic").

## Contributors

Elliot Reid
Kevin Touch
Nar Rai

## License

This project uses the following license: [MIT License](<https://opensource.org/licenses/MIT>).
