# CameraUploadsOrganizer
C# Windows Forms Application to take random images and videos and organize them by date.

Inspiration:

Dropbox mobile apps have a feature which allows you to automatically upload your images and videos to your Dropbox account.  This is nice, but it puts them all in a single folder called "Camera Uploads".

I guess I'm a bit of a traditionalist when it comes to photo organization, so my files are all sorted by date (format: yyyy-mm-dd).

And, you will have to pull this organization scheme out of my cold, dead, hands.

Faced with the daunting task of manually organizing 1700 photos, I created this simple little tool.  You give it a source folder (in my case 'Camera Uploads') and a destionation folder (in my case 'Photos') and let her rip.  It is hard-coded to store files in my preferred format (yyyy-mm-dd).

It tries to determine the date of the image/video based on file properties.  If that isn't an option, then it tries to determine the date based on the file name.  If that fails, then you are out of luck.  In my case, 20 of ~1700 could not be determined.

This tool DOES NOT delete any files; it does move them to a folder called 'archived' within the source folder.

USE AT YOUR OWN RISK.
