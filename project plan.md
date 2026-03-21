# Workout Tracker Project Plan

## Core Pages

### Login Page
- Logo
- Username/password fields
- Login button
- Maybe add Google or Microsoft account creation buttons later

### Main Page
- Current program or option to create new program if none exists
- Top menu with options
- Discover programs by other users (Add rating system)
- My programs
- Exercise library
- Account settings

### My Programs
- Current program displayed at top as favorite
- Program list below - grid with created date and other program info, plus delete button in grid
- Create new program button
- Ability to upload photos/videos for each workout

### Program Page
- Start program
- Edit program
- Delete program
- Tabs - overview/description - week by week view (support markdown in description)
- Program reviews - rating system
- Statistics page with charts

### Exercise Library
- Display exercises from database in a grid with various fields and filtering/sorting
- Add new exercise

### Exercise Page
*[To be defined]*

### Account Screen
*[To be defined]*

### Admin Screen
- User management
- Exercise management

### Stats Page
- Muscle worked frequency on calendar
- Muscle volume
- Weekly/monthly volume
- Total tonnage
- Total reps
- Charts - total tonnage per muscle group
- Personal Records (PRs)
- Ability to add autoregulation to programs - rating based/singles @8, etc

## Features & Requirements

### User Management & Permissions
- Add/edit/delete operations based on user role
- Add exercise - exercise marked as unverified until approved by admin
- Ability for each user to add tips on exercises with likes on each tip
- User ratings on each exercise
- Ability to select units (kg/lb) per user
- User roles: admin, content moderator, user, trial

### Exercise Features
- Support for super-sets, myo reps, antagonistic paired sets, agonist sets
- Separate exercises by movement type (e.g., split squat - single leg squat variation which also works quads and glutes)
- Maybe add tags for muscles worked (low back friendly, easy on the knees)
- WOD (Workout of the Day) support?
- Add stretching exercises as well (maybe connect them to muscle groups too, as well as tagging them for mobility issues they could fix)
- Cardio exercises as well?
- User can also log body measurements
- When viewing each exercise, see user history per exercise
- Add equipment field(s) per exercise to be able to sort by required equipment

### User Limitations
- Trial user is limited to creating programs with a max of 3 total programs, no exercise addition - account inactivates in 3 days??

## Technical Requirements

### Testing
- Use snapshot testing but limit snapshot length - split components where the length is exceeded and use shallow or mock the subcomponents
- Use PropTypes to validate props

### Data Structure
- Exercises should have tags on them, and tags should have a parent-child relationship between them (e.g., lat pulldowns can have the lats and biceps tags, both of which have parent tags upper back, arms which are under the upper body tag. Also add machine tag or something like that)
- Users should be able to define their own muscle group set count profiles for existing exercises (count pushups as tricep work, and in what proportion 1:1, 1:2, etc.)
- Related exercises should be picked based on tags (and ordered by tag type as hierarchy)

## Admin Features
- Admin screen for adding exercises