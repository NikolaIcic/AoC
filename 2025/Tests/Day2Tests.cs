using Advent2025;

namespace Tests;
public class Day2Tests : BaseTests<Day2>
{
    protected override string AcceptanceInput1 => "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124";
    protected override string AcceptanceInput2 => "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124";
    protected override object AcceptencePart1 => 1227775554L;
    protected override object AcceptencePart2 => 4174379265L;
    protected override object ExpectedPart1 => 52316131093;
    protected override object ExpectedPart2 => 69564213293;
    protected override int Day => 2;
}
