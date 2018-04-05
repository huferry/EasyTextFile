This library allows easy text file handling.

Example of use:

```csharp

// Saving to hello.txt using a single string content.
"Hello, World!\nGood morning.".SaveToFile("hello.txt");

// Saving to vici.txt using a string array as content.
new [] {
	"I see.",
	"I come.",
	"I conquer."
}.SaveToFile("vici.txt");

// Load content to an array of string.
string[] text = "vici.txt".LoadFile();

// Load content from an embedded resource text file.
// Only use the resource file name, without the namespace.
string[] lines = "news.txt".LoadFromEmbeddedResource();

// Joining array of string into one string.
var oneLiner = new[] {
	"Easy come",
	"Easy go"
}.ToText(); // == "Easy come\nEasy go"

// Splitting a string to array, by cartridge return.
var lines = "You jump,\nI jump.".ToLines(); // will be split to an array of 2 strings.

```
