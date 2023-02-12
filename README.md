# devUps
For the course DevOps at ITU

# Routing Notes
'/' 				= renders a user timeline

'/public' 			= renders a public timeline

'/<username>'		= renders a specific user's tweets

'/<username>/follow' 	= follows the user specified and redirects to following users timeline

'/<username>/unfollow'	= unfollows the user specified and redirects to the following users timeline

'/add_message' POST	= POST with a message under the user's tweet

'/login' GET		= login and redirects to user timeline

'/login' POST		= if succesful, login and redirect to user timeline, otherwise redirect to error

'/register' GET		= if logged in, goes to timeline

'/register' POST		= validates register form, redirects to login if succesful, and redirects to register if error

'/logout'			= Log out user and redirect to public timeline

