Routes 
- Movies
	GET
	/movies      - List All
	/movies/:id  - Get movie by id
	/movies&category=?

	POST
	/movies

	PATCH
	/movies/:id

	DELETE
	/movies/:id

-Users
	GET
	/user/:id							- Return User Data(Watched movies/Reviews/Profile Picture, Watchlist, Favorites, Followers/Following, Stats)
	/user/:id/movies/					- Return all User Movies
	/user/:id/reviews/					- Return all User reviews
	/user/:id/reviews/:movie_id			- Return User review in a specific movie
	

	POST
	/user
	/user/:id/movies/
	/user/:id/reviews/:movie_id

	PATCH
	/user/:id
	/user/:id/movies/:movie_id				
	/user/:id/reviews/:movie_id	

	DELETE
	/user/:id
	/user/:id/movies/:movie_id
	/user/:id/reviews/:movie_id	
