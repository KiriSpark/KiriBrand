# KiriBrand 

KiriBrand is a repository that contains:
* **the content** of my portfolio website 
* **KiriBrand.Static source code**: a dotnet core console application which can generate a static site based on markdown files and templates\static assets contained in the root content folder.

In addition to that, It uses github pages to host the generated website.

# Repository Structure

    .
    ├── content                 # Portfolio website source files (md files which represents the content, html templates and static assets)
    ├── docs                    # Documentation files and pictures (only for this repository)
    ├── src                     # Source code of KiriBrand.Static
    ├── tests                   # Test project of KiriBrand.Static
    └── README.md
    

# Installation 

## Dependencies

In order to build the website content, you will have to install:
* dotnet core 1.1
* node js

## Instructions

Once you have cloned the repository, from a command prompt:

* Restore required dotnet packages:
``` sh
$ cd src
$ dotnet restore
```

* Go back to repository root folder, restore npm packages and run the build process:

``` sh
$ cd .. 
$ npm install
$ npm run build
```

The last command will create a "dist" folder which will contain the generated website.

# Description

### Page Hierarchy
    .
    ├── IRazorPage 
    ├──── HomePage  
    ├────── MdRazorPageDecorator
    ├──────── MdContentResolver
    └──────── StaticAssetsPathResolver
