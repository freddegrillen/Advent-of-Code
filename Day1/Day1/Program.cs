// See https://aka.ms/new-console-template for more information

int current = 50;
int zeroCount = 0;

string input = Console.ReadLine();

while (input != "")
{
    var change = int.Parse(input.Substring(1));
    if (input[0] == 'L')
    {
        current -= change;
    }
    else
    {
        current += change;
    }
    AdaptCurrent();
    if(current == 0)
    {
        zeroCount++;
        Console.WriteLine($"zerocount is {zeroCount}. input: {input}");
    }
    input = Console.ReadLine();
}

Console.WriteLine(zeroCount);
Console.ReadLine();

void AdaptCurrent()
{
    if (current > 99)
    {
        current = current % 100;
    }
    if(current < 0)
    {
        current += 100;
    }

}
