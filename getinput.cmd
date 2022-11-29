SET DAY=0%1
SET DAY=%DAY:~-2%
echo %DAY%

curl  https://adventofcode.com/2022/day/%1/input --cookie "session=%AoCcookie%"