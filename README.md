﻿# signup-or-Login-with-OTP-verification

This is a signup and login system in asp.net 2012, the technologies used are html, css, mysql. 
Login and signup process are based on otp verification features with the help of Enablex Api.



The main idea behind this project is that the user will signup or login with the otp system, which is sent on the user mobile. No password is required to login or signup.
So only the particular user can only signup or login no other user can signup or login by using another users phone number. No sharing password.


How to use ?

Steps to use are as follows...

When user visits the website, there will be two option provided to the user Sign up or Login?

For new users
Step 1: First they need to click on the signup button.
Step 2 : Next on clicking on the signup button, it will redirect to the signup page where they need to enter their contact number in the contact panel.
Step 3 : After entering the mobile number click on the Button(Send OTP).

(After clicking on the button, the otp will be generated by the Enablex otp server and it will send the otp to the provided number throuh the API) 

Step 4 : On clicking the send otp button, it will redirect to the otp page where the page will ask to enter the otp, so user need to enter the otp in the otp 
			tectbox which is provided by the server.
Step 5 : After entering the otp, click on verify button.

(on clicking verify button, otp will be verified by the server and check whether the otp is correct or not and also it will check whether the user already 
			exists or no. If user already exists it will prompt a message [user already exists, login sucess])

If user is new
Step 6 : After clicking on verify button, it will ask to enter some personal details like name & email.
Step 7 : After filling up the data click on Submit button,
(Data will be submited and will be stored in the database)

If user already exists
Step 6 : After clicking on verify button it will prompt a message User already exists Login success.


Note : Enablex provides only 10 free credits to send otp to the mobile number, So now only 8 free credits are remaining.

