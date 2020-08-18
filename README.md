# Survey App

Users of this app are divided into two distinct roles, each having different
requirements:

-   _Survey Coordinators_ define and conduct surveys. This is an administrative
    function not available to normal users.
-   _Survey Respondents_ Complete surveys. They have no
    administrative privileges within the app.

## User Stories

### General

-   [X] Survey Coordinators can define, conduct, and view surveys and survey results.
-   [X] Survey Coordinators can login to the app to access functions, like defining a survey.
-   [X] Survey Respondents can answer a survey as a guest.

### Defining a Survey

-   [X] Survey Coordinator can define a survey containing 1-15 multiple choice questions.
-   [X] Survey Coordinator can define 1-10 mutually exclusive selections to each question.
-   [X] Survey Coordinator can enter a title for the survey.
-   [X] Survey Coordinator can click a 'Cancel' button to return to the home page without saving the survey.
-   [X] Survey Coordinator can click a 'Save' button save a survey.
-   [X] After saving the survey, a link for the survey should be created. (/survey/answer/`{id}`)

### Answering a Survey
-   [X] Survey Respondents should see the title of the survey and the questions below the title.
-   [X] Survey Respondent can select responses to survey questions by clicking on a checkbox
-   [X] Survey Respondents can click a 'Submit' button submit their responses to the survey.
-   [X] Survey Respondents can click a 'Cancel' button to return to the home page without submitting the survey.

### Conducting a Survey

-   [X] Survey Coordinator can open a survey by selecting a survey from a list of previously defined surveys
-   [X] Survey Coordinators can close a survey by selecting it from a list of open surveys

### Viewing Survey Results

-   [X] Survey Coordinators can select the survey to display from a list surveys
-   [X] Survey Coordinators can view survey results as in a pie chart showing the number of responses for each of the possible selections to the questions.

## Bonus features

-   [X] Survey Respondents cannot complete the same survey more than once (maybe save the **e-mail** or ~~IP address~~ of the respondent)
-   [X] Survey Coordinators and Survey Respondents can view graphical representations of survey results (e.g. pie, bar, column, etc. charts)

## TODO

-   [ ] Display if any form validation errors.