<p align="center"">
    <h1 align="center">Winlogg</h1>
    <p align="center">
        <img src="https://img.shields.io/badge/made%20with-C%23-blue?style=plastic">
        <img src="https://img.shields.io/badge/license-MIT-green?style=plastic">
        <img src="https://img.shields.io/badge/open%20source-red?style=plastic">
        <img src="https://img.shields.io/badge/suggestions-welcome-green?style=plastic">
        <img src="https://img.shields.io/github/last-commit/augus99/winlogg?style=plastic">
        <img src="https://img.shields.io/github/commit-activity/y/augus99/winlogg?style=plastic">
    </p>
</p>

## Description
This windows forms application logs all key strokes in a file using this [hook library](https://github.com/augus99/winhooks).

## Build
To build the project you will need dotnet installed on your computer, then type the following lines on your preferred terminal
```console
augus99@home:~/Desktop $ git clone https://github.com/augus99/winlogg.git
augus99@home:~/Desktop $ cd winlogg
augus99@home:~/Desktop/winlogg $ dotnet build
```

## Run
To run this project simply run this command
```console
augus99@home:~/Desktop/winlogg $ dotnet run
```

## Saving the key strokes data
Right click the tray icon with an exclamation sign after that click on `Export log` button of the context menu, then choose the path and save it.