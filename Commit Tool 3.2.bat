@echo off
@title Commit Tool 3.2
color 1a
@title Commit Tool 3.2 - Checking up files..
echo.
echo [ ! ] Catching up with files..
echo ______________________________
echo.
git remote -v
git remote rm origin

git init
git add .
@title Commit Tool 3.2
echo.
echo [Done!]
echo.
pause
cls
echo.
echo .::[ Welcome to the commit tool! ]::.
echo (Current version: 3.2! Hurray!)
echo.
echo.
echo.
echo What's new?
echo ________________________________________________________________
echo - AIO (All in one).
echo - Changed push/commit to make sure you push all from current run
echo - Removed useless code.
echo - Extra confirmations.
echo - No more pushing without commiting.
echo ________________________________________________________________
echo.
echo.
pause
cls
set "commited=false"
set "pulled=false"

set "URL=https://github.com/MLGC00KIE/EndlessRunner2k18"

:start
echo Set URL = %URL%
color 1a
@title Commit Tool 3.2
echo.
echo.
echo ---------------------{ ! }---------------------
echo REMEMBER: Always use this order when uploading:
echo              PULL - COMMIT - PUSH
echo ---------------------{ ! }---------------------
echo. 
echo AIO does all the work for you!
echo.
echo.
SET /P _inputname= Would you like to Clone, Pull, Commit, Push, All-In-One(AIO) or Exit: 
IF "%_inputname%"=="pull" GOTO :pull
IF "%_inputname%"=="push" GOTO :push
IF "%_inputname%"=="ForceItNow" GOTO :force
IF "%_inputname%"=="commit" GOTO :commit
IF "%_inputname%"=="clone" GOTO :clone
IF "%_inputname%"=="exit" GOTO :exit
IF "%_inputname%"=="aio" GOTO :aio
IF "%_inputname%"=="Pull" GOTO :pull
IF "%_inputname%"=="Push" GOTO :push
IF "%_inputname%"=="Commit" GOTO :commit
IF "%_inputname%"=="Clone" GOTO :clone
IF "%_inputname%"=="Exit" GOTO :exit
IF "%_inputname%"=="AIO" GOTO :aio
cls
echo [ ! ] ERROR - Unknown command!
goto :start

:clone
@title Commit Tool 3.2 - Cloning..
git clone %URL%
echo.
@title Commit Tool 3.2 - Done!
echo [Done!]
pause
cls
echo.
goto :start

:pull
set "pulled=true"
@title Commit Tool 3.2 - Pulling..
git pull %URL%
echo.
@title Commit Tool 3.2 - Done!
echo [Pull done!]
pause
cls
echo.
goto :start

:commit
set "commited=true"
echo.
SET /P _inputname= { ! } What message would you like to add: 
echo.
git commit -m "%_inputname%"
echo.
color 4f
SET /P _inputname= Commit ready, Ready to push?(yes/no): 
echo.
IF "%_inputname%"=="yes" GOTO :push
IF "%_inputname%"=="No" GOTO :noPush
IF "%_inputname%"=="Yes" GOTO :push
IF "%_inputname%"=="no" GOTO :noPush
IF "%_inputname%"=="YES" GOTO :push
IF "%_inputname%"=="NO" GOTO :noPush
IF "%_inputname%"=="y" GOTO :push
IF "%_inputname%"=="n" GOTO :noPush
IF "%_inputname%"=="Y" GOTO :push
IF "%_inputname%"=="N" GOTO :noPush
echo [ ! ] Error. - Unknown command.
goto :start

:noPush
echo.
cls
echo [Commit ready!]
goto :start


:push
color 1a
if "%pulled%" == "true" (goto :pulled)
if "%pulled%" == "false" (goto :pushErr)
goto :start

:pulled
echo.
echo Push: OK.
echo.
if "%commited%" == "true" (goto :confPush)
if "%commited%" == "false" (goto :pullErr)
goto :start

:pushErr
@title [ ! ] Commit Tool 3.2 - Error 11 - Pull Error - Did you pull?
echo.
cls
echo [ ! ] Error! 
echo Did you pull?
echo.
goto :start

:pullErr
@title [ ! ] Commit Tool 3.2 - Error 12 - Commit Error - Did you commit?
echo.
cls
echo [ ! ] Error! 
echo Did you commit?
echo.
goto :start

:confPush
echo. 
echo Commit: OK.
echo.
color 4f
SET /P _inputname= Are you sure?(yes/no): 
echo. 
IF "%_inputname%"=="yes" GOTO :goPush
IF "%_inputname%"=="No" GOTO :start
IF "%_inputname%"=="Yes" GOTO :goPush
IF "%_inputname%"=="no" GOTO :start
IF "%_inputname%"=="YES" GOTO :goPush
IF "%_inputname%"=="NO" GOTO :start
IF "%_inputname%"=="y" GOTO :goPush
IF "%_inputname%"=="n" GOTO :start
IF "%_inputname%"=="Y" GOTO :goPush
IF "%_inputname%"=="N" GOTO :start
goto :start

:goPush
color 1a
@title Commit Tool 3.2 - Pushing..
git remote add origin %URL%
git pull %URL%
git push -u origin master
@title Commit Tool 3.2 - Done!
echo.
echo [Done!]
pause
echo.
goto :done

:aio
echo.
color 4f
SET /P _inputname= Are you sure?(yes/no): 
echo.
IF "%_inputname%"=="yes" GOTO :aigo
IF "%_inputname%"=="No" GOTO :start
IF "%_inputname%"=="Yes" GOTO :aigo
IF "%_inputname%"=="no" GOTO :start
IF "%_inputname%"=="YES" GOTO :aigo
IF "%_inputname%"=="NO" GOTO :start
IF "%_inputname%"=="y" GOTO :aigo
IF "%_inputname%"=="n" GOTO :start
IF "%_inputname%"=="Y" GOTO :aigo
IF "%_inputname%"=="N" GOTO :start
goto :start

:aigo
color 1a
@title Commit Tool 3.2 - Pulling..
git pull %URL%
@title Commit Tool 3.2
echo.
SET /P _inputname= { ! } What message would you like to add: 
echo.
git remote add origin %URL%
@title Commit Tool 3.2 - Commiting..
git commit -m "%_inputname%"
@title Commit Tool 3.2
git remote add origin %URL%
@title Commit Tool 3.2 - Pushing..
git push -u origin master
echo.
@title Commit Tool 3.2 - Done!
echo [Done!]
pause
echo.
goto :done

:done
cls
@title Commit Tool 3.2
echo.
color 2f
echo [Finished!]
echo (To make sure it went well, Please either check the github page, Or if you have a bot, check if it says anything.)
echo.
echo.
echo ///////////////////////////////
echo You can close this program now.
echo Thank you for using it.
echo ///////////////////////////////
echo.
echo.
pause
goto :start

:force
color 1a
@title Commit Tool 3.2 - Pulling..
git pull %URL%
@title Commit Tool 3.2
echo.
SET /P _inputname= { ! } What message would you like to add: 
echo.
git remote add origin %URL%
@title Commit Tool 3.2 - Commiting..
git commit -m "%_inputname%"
@title Commit Tool 3.2
git remote add origin %URL%
@title Commit Tool 3.2 - Pushing..
git push -u origin master --force
echo.
@title Commit Tool 3.2 - Done!
echo [Done!]
pause
echo.
goto :done


:exit
echo Thank you for using this program!
echo Goodbye! :)
pause