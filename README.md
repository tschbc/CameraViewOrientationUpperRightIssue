CameraView always sets `upper-right` to EXIF orientation tag.

1. Launch project on physical iOS device
2. Set breakpoint on MainPage.xaml.cs:39
3. Take picture in portrait orientation
4. Either copy base64 from Debug output or from variable inspection
5. Save base64 in text file on your computer
6. Convert base64 into a binary file (does not need a .jpg extension)
7. View exif tags (I used `file <filepath>` from bash from Git for Windows)
8. See that the orientation value is always the same
9. Repeat steps 3 to 8 from different device orientations
