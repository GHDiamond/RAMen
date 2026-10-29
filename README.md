# RAMen
A tiny and useless project for filling up RAM of any size at impressive speeds. Also can elapse the time used to fill up the RAM and stats to show how much was filled up (results may be inaccurate.) Also includes a tiny snippet version of the code. Written as a ConsoleApp in C#

## How to use
1. Choosing between `Program.cs` and `snippet.cs`
   - `Program.cs` is useful when you're trying to test the RAM-filler for fun, but don't want the program to just exit with a StackOverflow exception and want a bunch of statistics over things like:
     - How much RAM was filled
     - How much time it took
      - How many lists were created
   - `snippet.cs` is very small, one line and good for pranks
2. Getting the code<br>
   When you're on the homepage of this repo, click on the code you're going to download, and on the ribbon right above the actual code, press the small download icon. You can alternatively just copy and paste the code
3. Installing a compiler<br>
   Select a C# compiler/editor to install (I would NOT recommend using an online compiler due to their limitations with RAM.) Then, follow the instructions from that compiler on how to install and use that compiler
   With a good editor like Visual Studio you can get good and accurate diagnostics over what's actually happening
5. Running the code<br>
   Use the guide for the compiler/editor of how to create projects and run C# code. Copy + Paste the code from the repo to the editor or simply use the file you downloaded.

## How the RAM-filler it works
Let's look at the snippet.cs:
```csharp
List<Int128[]>a=[];for(;;){a.Add(new Int128[Array.MaxLength]);}
```
Okay, that's hard to read. Let's make it more clear:
```csharp
List<Int128[]> list = [];
for ( ; ; )
{
  list.Add(new Int128[Array.MaxLength]);
}
```
That's much better! Now let's break it down:<br><br><br>
1. Creating the list
```csharp
List<Int128[]> list = [];
```
This creates a list of arrays (basically lists, but simpler) of 128-bit signed integers.<br>
Why lists? We can't just keep creating arrays without its list, because declaring (creating something and writing it to RAM) something inside a loop will just be erased once we get to the next loop, which sucks for a project like this. But by adding to a list created outside the loop, we simply get to keep what we declared, how fun!<br>
Why arrays? Because when creating a new array, we already allocate all the 128-bit signed integers. It's easier to add them to the list than creating lists and manually filling them up with integers.<br>
Why 128-bit signed integers? Because it's efficient to allocate and take up a lot of storage. We can't use strings, though, because their size can change.<br><br>
2. The loop
```csharp
for ( ; ; )
{
  ...
}
```
This loop repeats on and on "forever" but eventually the program will have to throw a StackOverflow exception, which just means we've filled up our RAM!<br><br>
3. Adding the arrays
```csharp
  list.Add(new Int128[Array.MaxLength]);
```
This will create a new instance of the array. It contains empty 128-bit signed integers, but even though they are empty, but they're still wasting RAM. One array is already guaranteed to fill up the RAM since:<br>
`2,147,483,591 (Array.MaxLength or the array size) * 16 bytes (size of a Int128) = 34,359,737,456 bytes (or ~32 GiB)`<br>
But since there are some computers that have more free RAM than that, we needed to create the list and make the loop so that it keeps adding the arrays.
