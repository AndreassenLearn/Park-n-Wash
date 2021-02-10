# Park'n'Wash
## About
Park'n'Wash enables simulation of a 2-in-1 parking and car wash controller. Both are managed using tickets.

The application is able to have multiple car washes running independently of each other. When a washing ticket is bought using the terminal based UI; it's possible to select from different types of wash programs with different sets of processes (e.g. rinsing or undercarriage wash). The current process of a car wash can be viewed through the UI as well as statistics for each car wash. A wash can also be canceled.

The parking system features different types of parking slots (e.g. for electric vehicles, trailers or buses), that are all handled from a single repository. The price for a parking ticket is based on type, included services, and time between check in and check out.

Both washing and parking tickets are printed to the console, where information about price, services, ticket number/ID, and more is shown.

## Usage
### General
The UI consist of numbered lists and a few sub-options, which all can be navigated using just numbers (0-9), single chars ('Y'/'N'), and ´Enter´ for confirm. For how the lists are created refer to *Technical Implementation*.

A wrongly entered value will be asked for again.

### Parking
#### Check in
When choosing the `Park: Check In` option, you'll be presented to all types of parking slots and how many of them that are free. After selecting a slot type, one or multiple sub-options will be shown one by one. These can be answered with 'Y', 'y', 'N', or 'n' and will be added to the ticket according to your input.
##### If successful; the ticket will be printed to the console:
```
# ##
# ##  Ticket: 0 - Slot: 0
# ##
# ##  Start Time: 09-02-2021 14:37:30 - End Time: N/A
# ##  Total hours: 0
# ##  Charging: Y
# ##
# ##  Price: 0 kr.
# ##
```
##### Possible reasons for ticket not being printed:
* No free slots (Message will be shown).
* All slots has been taken during ticket registration (No message will be shown).

#### Check out
When choosing the `Park: Check Out` option, you'll be prompted to enter the ticket ID of your ticket. This can be found in the `Ticket` field on your parking ticket.
##### If successful; the ticket will be printed to the console again, but now with end time, total hours, and a final price:
```
# ##
# ##  Ticket: 0 - Slot: 21
# ##
# ##  Start Time: 09-02-2021 14:50:19 - End Time: 09-02-2021 14:50:30
# ##  Total hours: 0,003
# ##  Charging: N
# ##
# ##  Price: 0,05 kr.
# ##
```
##### Possible reasons for ticket not being printed:
* Entered ID is invalid (Message will be shown).

### Car Wash
#### Order
When choosing the `Wash: Order` option, you can select what type of wash you want and your ticket will be printed:
```
# ##
# ##  Ticket: 0
# ##
# ##  Price: 69,99 kr.
# ##
```

#### Start
When choosing the `Wash: Start` option, you'll be prompted to enter the ticket ID of your ticket. This can be found in the `Ticket` field on your washing ticket.
##### If successful; a message like the following will be printed:
```
Basic Wash in car wash #0 has started.
```
##### If there's no free car washes, a message like the following will be printed instead:
```
Car wash #0 is currently running. You are number 1 in the queue.
Estimated finish time for currently running wash is: 10-02-2021 08:39:21.
```
The wash will then automaticly start when the car wash is free. The start message (`Basic Wash in car wash #0 has started.`) will be printed when this happens.
##### When a wash is done, a message like the following will be printed:
```
Basic Wash in car wash #0 has finished.
```

#### Cancel
When choosing the `Wash: Cancel` option, you'll be prompted to enter the number/ID of the car wash. This can be found in the message you got when the wash started (e.g. `Basic Wash in car wash #0 has started.`).
##### If successful; a message like the following will be printed:
```
Basic Wash in car wash #0 has stopped.
```
##### Possible reasons for previous message not being printed:
* Entered car wash number/ID is invalid (Message will be shown).
* No wash is running in the targeted car wash.

#### Inspect
When choosing the `Wash: Inspect` option, you'll be presented with a status from each car wash. This includes what process of the wash program it's currently running:
```
ID: 0, Is running: Y, Finished at: 09-02-2021 15:56:42, Current process: Undercarriage Wash
ID: 1, Is running: N
```

#### Statistics
When choosing the `Wash: Statistics` option, you'll be able to choose weather you want to show or update statistics for each of the car washes. If choosing show and there's no statistics, these will be generated asynchronously and something like the following will be printed:
```
There's no statistics for car wash #0.
Generating statistics for car wash #0 now.
```
##### To show the generated statistics; simply navigate back and they'll show:
```
Basic Wash: 13
Premium Wash: 5
Deluxe Wash: 1
```
##### If the statistics are requested before the generation is done, a message like the following will be printed instead:
```
Statistics for car wash #0 is currently being generated or updated. Nothing to show yet.
```
##### To update the statistics for a car wash, the update option must be used and the asynchronous generation will start:
```
Generating statistics for car wash #0 now.
```

## Logging
In the same directory where the Park'n'Wash executable is located, log files for car washes will be created/updated after each wash. These are used to create the statistics for the car washes, but also privides extra information not currently used in the statistics, like finish state and time. The log files will be named like so; `log_CarWash0.csv`, where the number after "CarWash" is the ID of the car wash.

## Technical Implementation
### Classes
A class diagram called 'ClassDiagram.cd' can be found in the project folder; 'Park'n'Wash'.

### Option Menues
The option menues is build using a list of UserOption objects. By UserOption implementing the IPrintable interface, UserInteraction can print a numbered list of the UserOption objects using the PrintableString() method provided by the interface.

Whatever UserOption chosen (returned from UserInteraction after user inputs number) will have it's associated method ran. UserOption have delegate templates stored required for all the methods, as well as the delegates themselves, it should be able to call when chosen. However it's only designed to have *one* method set at a time.

UserOption contains a contructor for each supported template and it's parameters and properties with various types to hold values for the parameters. The call of the method happens in `UserOption.Execute`, where the assigned delegate method is called with the correct parameters.

## Known Issues and Limitations
* No "Go Back" option in menues.
* Weather service is included or not, is not shown on parking ticket.
* Parking tickets with included service cannot be checked out.

## Versioning
### v0.2.1
* Corrected README.md.
### v0.2.0
* Added car wash functionality.
* Added missing bits in parking functionality.
* Logging of car washes.
* Updated ClassDiagram.cd.
* Added README.md.
### v0.1.0
* Early pre-release.
