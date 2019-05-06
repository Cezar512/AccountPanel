# AccountPanel
It's CRUD API for primitive account panel for game purposes 

It's being created with rules of Onion architecture and Domain-driven design aproch. Atleast it is what I'm tring to do. It's my first complex project thats why I decied to pull it here. This project leaning on web tutorials there is a couple of aspects that I may not be completly sure about or even wrong. I'm still learning be aware of that :).

# A bit about technology
I've used here AutoFac to mainly register interfaces with thier implementation, dependency injection. To store data I've used a MongoDB database it was easier to me map a non-sql database back then when I've started this project. AutoMapper maps a data from database to flat DTO objects. There are JWT tokens applied for authentication.
