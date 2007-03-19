@ echo off

rem ############################################
rem #                                          #
rem # CONVERTER (table,text) -> ltx            #
rem #                                          #
rem # be sure to have correctly formatted      #
rem # input files!                             #
rem #                                          #
rem # table: one title per row, followed       #
rem #        by exactly one tab and the song   #
rem #        number.                           #
rem # texts: first line only song number       #
rem #        next lines (arbitrary amount)     #
rem #        for text. Next song begins where  #
rem #        the next song number is found.    #
rem #                                          #
rem # INDICATE THE PATHS OF THESE FILES        #
rem # IN CONSOLE! Relative paths start         #
rem # in the converter-directory.              #
rem #                                          #
rem ############################################

Converter.exe
pause