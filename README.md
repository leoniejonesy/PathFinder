# PathFinder
C#.NET console application to find the shortest path between two given words from a file containing a list of words.

#
### Expectations
Command line arguments are as follows:

```bash
--DictionaryFile
--StartWord
--EndWord
--ResultFile
```
StartWord and EndWord are expected to be found in the DictionaryFile file

#
### Process
After reading the given requirements, my initial thoughts about how to solve the problem were that I would probably need to use either a Breadth-First or Depth-First search.  I wasn't sure which, so I used Stack Overflow and other online resources such as blog posts to do a bit of research into both algorithms and which one would be best suited for the task. 

I chose to use BFS in this case, largely due to the fact that I may not have to visit every word in the data structure to find the end word, therefore wouldn't necessarily need to traverse the full depth to achieve the desired result. 

I then needed to decide how best to structure the data, in a way that would suit a BFS.  I did some further research on linked data structures and found that an adjacency list would be the best fit. 

This is when I started thinking about how I would structure my project.  I knew that I would need to split the program into phases, of which could be tested in isolation:
1. Read a file
2. Represent the data
3. Find the shortest path
4. Write to file 

This is when I created my interfaces.  I knew what each phase needed to do, and what they required in order to do it.  I chose to use interfaces so that the solution could be extended rather than modified in future.  For example if there were a requirement to find the longest path between two given words I might like to implement a DFS solution that would be able to use the same interface, therefore extend rather than modify the existing code.

Once I had my interfaces in place I started to flesh out some of the implementation for each of the phases I identified above. In each phase, when the code was at a point I was happy with, I wrote unit tests that would test what I had already written and also drive some additional implementation such as error handling.

After testing I started refactoring.  I knew that I wanted to remove any hard coded values such as the maximum word length and put them into a configuration file.  This means that if the program were to be published, I could change the value if needed without having to modify the code.  I also wanted to explore using the latest .NET Dependency Injection Container methods, which I read about in a blog post on Dev Community.

Finally I added some validation for the command line arguments, checked over all of my tests and implementation and I think it's just about ready for QA!
