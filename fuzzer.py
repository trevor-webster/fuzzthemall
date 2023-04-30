import sys
import random
import array
import math
import string


prng_seed=int(sys.argv[1])
num_of_iterations=int(sys.argv[2])
random.seed(prng_seed)

try:
    with open("seed", "rb") as f:
        data = f.read()
        data = array.array("B", data)
    
except:    
    data = bytearray(random.getrandbits(8) for _ in range(num_of_iterations))
    data = array.array("B", data)
    

for i in range(num_of_iterations):
    data[i % len(data)] = data[i % len(data)] ^ random.getrandbits(8)


for i in range(0, math.ceil(num_of_iterations / 500) ):
    for j in range(10):
        data.append(random.getrandbits(8))
    

data.extend((65 for _ in range(1000))); #one time pad
for i in range(8):
    data[i] = 0x7F
sys.stdout.buffer.write(bytearray(data))
