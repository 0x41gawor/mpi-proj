using mpi_proj;
using mpi_proj.System;

// var main = new Main();
// main.Run();

var s = new Scheduler();


var c1 = new Client(1, StreamEnum.B);
var c2 = new Client(2, StreamEnum.C);
var c3 = new Client(3, StreamEnum.B);
var c4 = new Client(4, StreamEnum.C);
var c5 = new Client(5, StreamEnum.B);
var c6 = new Client(6, StreamEnum.A);

s.Push(c1);
s.Push(c2);
s.Push(c3);
s.Push(c4);
s.Push(c5);
s.Push(c6);
Console.WriteLine(s);
while (!s.IsEmpty)
{
    Console.WriteLine(s.Pop());
}
