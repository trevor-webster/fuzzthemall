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


for (int i = 1; i < num_of_iterations; i++)
{
    
    data[i] = (byte)(data[i] ^ RandomNumberGenerator.GetInt32(byte.MaxValue));

    if (i % 500 == 0)
    {
        byte[] addedBytes = RandomNumberGenerator.GetBytes(10);
        sw.Write(addedBytes);
    }
}

sw.Write(data);
sw.WriteLine();
sw.Flush();


