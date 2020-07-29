# Survey App

Users of this app are divided into two distinct roles, each having different
requirements:

-   _Survey Coordinators_ define and conduct surveys. This is an administrative
    function not available to normal users.
-   _Survey Respondents_ Complete surveys. They have no
    administrative privileges within the app.

## User Stories

### General

-   [ ] Survey Coordinators can define, conduct, and view surveys and survey results.
-   [ ] Survey Coordinators can login to the app to access functions, like defining a survey. (/manage)
-   [ ] Survey Respondents can answer a survey as a guest.

### Defining a Survey

-   [ ] Survey Coordinator can define a survey containing 1-10 (?) multiple choice questions.
-   [ ] Survey Coordinator can define 1-5 mutually exclusive selections to each question.
-   [ ] Survey Coordinator can enter a title for the survey.
-   [ ] Survey Coordinator can click a 'Cancel' button to return to the home page without saving the survey.
-   [ ] Survey Coordinator can click a 'Save' button save a survey.
-   [ ] After saving the survey, a link for the survey should be created. (/survey/{id})

### Answering a Survey
-   [ ] Survey Respondents should see the title of the survey and the questions below the title.
-   [ ] Survey Respondent can select responses to survey questions by clicking on a checkbox
-   [ ] Survey Respondents can click a 'Submit' button submit their responses to the survey.
-   [ ] Survey Respondents can click a 'Cancel' button to return to the home page without submitting the survey.
-   [ ] Survey Respondents can see an error message if 'Submit' is clicked, but not all questions have been responded to.

### Conducting a Survey

-   [ ] Survey Coordinator can open a survey by selecting a survey from a list of previously defined surveys
-   [ ] Survey Coordinators can close a survey by selecting it from a list of open surveys

### Viewing Survey Results

-   [ ] Survey Coordinators can select the survey to display from a list of closed surveys
-   [ ] Survey Coordinators can view survey results as in tabular format showing the number of responses for each of the possible selections to the questions.

## Bonus features

-   [ ] Survey Respondents cannot complete the same survey more than once (maybe save the e-mail or IP address of the respondent)
-   [ ] Survey Coordinators and Survey Respondents can view graphical representations of survey results (e.g. pie, bar, column, etc. charts)
