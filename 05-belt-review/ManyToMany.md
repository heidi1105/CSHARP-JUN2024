# Notes on OneToMany

## 1. Project setup
### Suggestions: Do not start until you got the 1:n working

- Create a middle table with 2 Foreign keys (UserId & TripId)
  ``` public int UserID {get; set;} ```
- Make sure each foreign key has the corresponding Nav property 
  ``` public User? User {get; set;} ```
- Make sure the 1:n table (User / Trip) include the Inverse Navigation property
  ``` public List<UserTripInterest> Interests {get;} = new(); ```

## 2. Example query
- When writing queries, take a look at the ERD to decide what to include
- Can always dig deeper by using .ThenInclude()
```cs
    Trip? trip = _context.Trips
                .Include(trip => trip.Host) // access to Host info

                .Include(trip => trip.Interests) // access to interest (only UserId & TripId)
                .ThenInclude(interest => interest.User) 
                // From each interest, adding access to the corresponding user

                .FirstOrDefault(trip=>trip.Id == tripId);
```
![alt text](image-1.png)

### HINT on queries
```.Any(item => item.price > 10 )``` 
  - to find if any item in the list fits the criteria 
  - Could be very helpful in checking if the user liked the item
  
``` .Sum(item => item.price) ```
  - To get the sum of all the item price

### HINT on Create Itin / Comments on a details page
#### For successful submission
- If you need to Redirect back to the Details page, it may require the Path variable and you will need to put it in argument as well. 

```cs
    [HttpGet("trips/{tripId}")]
    public IActionResult TripDetailsPage(int tripId)
    {} // DetailsPage require tripId in the path

    [HttpPost("trips/itins/new")]
    public IActionResult NewItinProcess(UserTripItin newItin)
    {
      // If the form is valid: provide tripId 
      return RedirectToAction("TripDetailsPage", new {tripId = newItin.TripId});
    }
```
#### For Invalid submission
```cs
    [HttpPost("trips/itins/new")]
    public IActionResult NewItinProcess(UserTripItin newItin)
    {
        if(!ModelState.IsValid)
        {
          // Make sure you include the query required in DetailsPage
          Trip? trip = _context.Trips.________ // Fill in the necessary query

          // And include it when returning the View
          return View("TripDetailsPage", trip); 
        }
        // Success submission logic to be filled by you
    }
```
