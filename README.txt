Before initial launch of the Solution please make sure to have a current version of Docker running on your system. 
Then run the following script:
--For Linux/Mac users: please run: up.sh
--For Windows users: please run.bat 

This will create Create a Database(PostgreSQL) & according Management System(PgAdmin) as well as a network. 
For persistent storage a Volume will be added. 

Login for pg Admin: admin@localhost 
                --pwd: mysecretpassword


Initially the web- App will ad admistrative User: Admin@MontiniInk.de
                --pwd: veryunsafepassword
                For further information please refer to /MontiniInkEF/efUserRepository

After use make sure to run the according down.bat/down.sh script ro stop and remove containers & network 
and remove the created Volume.

For Some Views I took the liberty to use prebuild Bootstrap Snippets for cosmetic reasons (E.g. in Layout-> Carousel, Blog/Index ->Representation of a post ),
but edited all of them to dynamicly adapt to the Data passed to the View. 

Enjoy!



