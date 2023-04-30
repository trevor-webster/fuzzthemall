using System.Security.Cryptography;
string _seed_ = "seed";
int prng_seed = Int32.Parse(Environment.GetCommandLineArgs()[1]);
int num_of_iterations = Int32.Parse(Environment.GetCommandLineArgs()[2]);

byte[] data;
try
{
    FileStream fs = File.OpenRead(_seed_);
    data = new byte[fs.Length];
    await fs.ReadAsync(data);
}
catch
{
    data = new byte[500];
    RandomNumberGenerator.Fill(data);
}
var sw = new StreamWriter(Console.OpenStandardOutput());
sw.AutoFlush = false;
Console.SetOut(sw);

for (int i = 0; i < num_of_iterations; i++)
{
    // data[i % data.Length] = (byte)(data[i % data.Length] ^ RandomNumberGenerator.GetInt32(byte.MaxValue));
    // sw.BaseStream.WriteByte((byte)'A');
    sw.Write('A');
}

// sw.BaseStream.Write(data,0,data.Length);
// for (int i = 0; i < (num_of_iterations / 500); i++)
// {
//     byte[] addedBytes = RandomNumberGenerator.GetBytes(10);
//     sw.Write(System.Text.Encoding.UTF8.GetString(addedBytes));    
// }

sw.BaseStream.WriteByte(0x00);
sw.Flush();


