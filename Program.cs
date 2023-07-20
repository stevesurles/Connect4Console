// See https://aka.ms/new-console-template for more information
using Connect4Console;

Console.WriteLine("Connect 4");

Grid grid = new Grid(6, 7);
Game game = new Game(grid, 4, 10);
game.play();
