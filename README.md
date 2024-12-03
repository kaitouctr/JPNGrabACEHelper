# JPN Grab ACE Helper
A program that reports RNG advances that yield Pokemon compatible with the Japanese variant of the FRLG mail glitch. This should give PIDs that can be used with [this tool by デテロニー](http://detelony.blog.fc2.com/blog-entry-29.html) to transform a Pokemon into a grab ACE Pokemon.

## Build Instructions
### Prequisites
- .NET 8.0
- Your favourite terminal
- Git
### Steps
1. Launch your favourite terminal
2. `git clone https://github.com/kaitouctr/JPNGrabACEHelper.git`
3. `cd JPNGrabACEHelper`
4. `dotnet build JPNGrabACEHelper.sln`
5. `dotnet` should tell you where the built application is but if not, check `JPNGrabACEHelper/JPNGrabACEHelper/bin/Debug/net8.0`

## How to run
Make sure that .NET 8.0 is installed.
### All platforms
1. Launch your favourite terminal in the directory where you unzipped the archive
### Windows
2. `.\JPNACEHelper.exe`
### Mac OS / Linux
2. `chmod +x JPNACEHelper`
3. `./JPNACEHelper`

## Acknowledgements
- Slashmolder's RNGReporter for inspiration on the implementation of LCRNG32 in C#
- Lincoln-LM's JS-Finder for inspiration on implementing wild encounter RNG.

## License
© 2024 Luong Truong

This program is licensed under the terms of the MIT license, see `LICENSE` for more information.
