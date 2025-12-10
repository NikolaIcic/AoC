using Advent2025;

namespace Tests;
public class Day10Tests : BaseTests<Day10>
{
    protected override string AcceptanceInput1 => "[.##.] (3) (1,3) (2) (2,3) (0,2) (0,1) {3,5,4,7}\r\n[...#.] (0,2,3,4) (2,3) (0,4) (0,1,2) (1,2,3,4) {7,5,12,7,2}\r\n[.###.#] (0,1,2,3,4) (0,3,4) (0,1,2,4,5) (1,2) {10,11,11,5,10,5}";
    protected override string AcceptanceInput2 => "[.##.] (3) (1,3) (2) (2,3) (0,2) (0,1) {3,5,4,7}\r\n[...#.] (0,2,3,4) (2,3) (0,4) (0,1,2) (1,2,3,4) {7,5,12,7,2}\r\n[.###.#] (0,1,2,3,4) (0,3,4) (0,1,2,4,5) (1,2) {10,11,11,5,10,5}";
    protected override object AcceptencePart1 => 7;
    protected override object AcceptencePart2 => 33;
    protected override object ExpectedPart1 => 390;
    protected override object ExpectedPart2 => 0L;
    protected override int Day => 10;
}
