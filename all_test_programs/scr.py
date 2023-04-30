import os

for i in range(0,10):
    with open(f"all_test_programs/prog_{str(i)}.txt", "w") as output:
        output.write(f"{i}\n1000\n")
        output.close()
    os.system(f"python3 ./fuzzer.py 1 1000 | all_test_programs/prog_{str(i)}")
    # os.system(f".{name} ${print('A'*1000)}")

