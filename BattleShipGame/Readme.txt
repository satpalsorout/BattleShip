1.Provide the input the through the file(input.txt)
2.Put the file in the applications bin folder if not present there
3.see the output and error message on the console. 


Instructions:-
1.Provide only single test case data at a time in file(input.txt) 
2.For Input use the specific format the provide in sample problem.


Idea:-

1.Player(Class) is created first for all Players.
2.Every Player has the BattleArea(Class) as property with Width,Height,Staus As Empty or Filled
3.Every BattleArea has Ship(Class),Postion(Class),Cells(Class) Which also have Position(Class) with status as Empty or Filled AS Property.
4.Ship has lstCells(List),ShipType(Enum),position(Class) as Property   
5.On the every BattleArea which is specific to the player the ships are allocated after checking the cells in all lstCells should be avalaible for all players as no overlap positions.



Working:-
1. BattleArea is created with provided Height and Width for all players.
2. The Ships are allocated over the battle area with the provided Height,Widht on given positions after checking the availibility on all Players battleares and also setting the status cells on BattleArea as Filled if availibility is posible.
3. The Fire Method of player class is used to hit the positions as I already assigns the list of hitting positions in list of missiles.
4. If Hit is success the again next Hit if missiles are available otherwise the swipe the Players in Play method as recusivly called untill both  have left missiles or one won.  
5. Fire Method is called if matching the cordinates in any cells on SHip class is availabe also we increase the hitCount over the Cells as maintening the Hit Counts for Ship Types AS P need single Hit  and Q need Double to set the status as Damaged.
6. Checking the  all cells of all ships are damaged then Player Won checking on every Fire call.