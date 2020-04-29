# FastImage

## What

FastImage is a small tool created by [Kris van der Mast](www.krisvandermast.com). It is meant to quickly move images from a folder to subfolders.

## How to use

Start up the application, specify a folder<sup>1</sup> and for reach image shown move it to the allowed subfolders ranging from 0 to 9. If a file with the same name already exists in the subfolder then the filename will be suffixed with a `_Guid` as not to overwrite the already existing image. Currently images with following extensions are shown:

- jpg
- jpeg
- gif
- png

## Technology

This tool was created with .NET Core 3.1 based on the Winforms template.

## Notes

<sup>1</sup>: currently the folder is set fixed in code to `C:\px\`. This will likely change in an update of the tool.