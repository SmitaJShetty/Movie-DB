### Movie-DB
A c# based movie repository

Service is built on webapi 2. This program uses in memory cache using concurrentlist. A better alternative would be using Redis. Application has been structured in a way that that can be switched for the existing cache by changing bindings on the service.  Redis’s requirement for reverse index key and paucity of time on my side, made this alternative, not a feasible option for this project for me. 

#### Design decisions

1. Store performs cache manipulation and cache as such is agnostic of other dependencies such as the MovieDataSource. Another cache (such as Redis) will be easy to incorporate. 
2. I have used attribute routing instead of conventional webapi routing as it is my personal choice. 
3. I have used dynamic linq (over linq to objects) as I find it is less time consuming during development.
4. I believe a service api has to do only the bare minimum of what is expected and should do it well. Therefore, I throw exceptions to the client to handle and tailor accordingly. In some cases, where .net might not send out appropriate messages to display, I have created threadbare custom exception classes.
5. All data is fetched from cache. Update and Create is made both in the cache and the moviedatasource. Syncing during a fresh from both data sources is simpler this way.
6. Admin controller exposes a url to invalidate and refresh the cache. A service can use this URI to perform the once in a day update of the movie library. http://localhost:<port>/admin/refreshcache. 
7. Ninject bindings are set up in webapi
