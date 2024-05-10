
int[] blockSize = { 100, 500, 200, 300, 600 };
int[] processSize = { 212, 417, 112, 426 };
int bSize = blockSize.Length;
int pSize = processSize.Length;
MemoryAllocation allocate=new MemoryAllocation(pSize);

allocate.BestFit(blockSize, bSize, processSize, pSize);



class MemoryAllocation
{
    public int[] allocation;

    public MemoryAllocation(int processSize)
    {
        allocation = new int[processSize];
    }
    public void FirstFit(int[] blockSize,int bSize,
        int[] processSize,int pSize)
    {
        for(int i=0; i<allocation.Length; i++)
            allocation[i] = -1;

        for(int i=0; i<pSize; i++)
        {
            for(int j=0; j<bSize; j++)
            {
                if (blockSize[j] >= processSize[i])
                {
                    allocation[i] = j;

                    blockSize[j]-=processSize[i];

                    break;
                }
            }
        }

        Console.WriteLine("\nProcess No.\tProcess Size\tBlock No.");
        for(int i=0; i<pSize; i++)
        {
            Console.Write(" "+(i+1)+"\t\t"+
                                processSize[i]+"\t\t");
            if (allocation[i] != -1)
                Console.Write(allocation[i] + 1);
            else
                Console.Write("Not Allocated");
            Console.WriteLine();
        }
    }
    public void BestFit(int[] blockSize,int bSize,
        int[] processSize,int pSize)
    {
        for (int i = 0; i < allocation.Length; i++)
            allocation[i] = -1;
        
        for(int i=0;i<pSize;i++)
        {
            int bestIndex = -1;
            for(int j=0;j<bSize;j++)
            {
                if(blockSize[j] >= processSize[i])
                {
                    if(bestIndex==-1)
                        bestIndex = j;
                    else if(blockSize[bestIndex]>blockSize[j])
                        bestIndex = j;
                }
            }
            if(bestIndex!=-1)
            {
                allocation[i] =bestIndex;

                blockSize[bestIndex] -= processSize[i];
            }
        }
        Console.WriteLine("\nProcess No.\tProcess Size\tBlock No.");
        for(int i=0;i<allocation.Length;i++)
        {
            Console.Write(" " + (i + 1) + "\t\t" + processSize[i] + "\t\t");
            if (allocation[i] != -1)
                Console.Write(allocation[i] + 1);
            else
                Console.Write("Not Allocated");
            Console.WriteLine();
        }
    }
    public void WorstFit(int[] blockSize, int bSize,
        int[] processSize, int pSize)
    {
        for (int i = 0; i < allocation.Length; i++)
            allocation[i] = -1;
        for (int i = 0; i < pSize; i++)
        {
            int worstIndex = -1;
            for (int j = 0; j < bSize; j++)
            {
                if (blockSize[j] >= processSize[i])
                {
                    if (worstIndex == -1)
                        worstIndex = j;
                    else if (blockSize[worstIndex] < blockSize[j])
                    {
                        worstIndex = j;
                    }
                }
            }
            if (worstIndex != -1)
            {
                allocation[i] = worstIndex;

                blockSize[worstIndex] -= processSize[i];
            }
        }
        Console.WriteLine("\nProcess No.\tProcess Size\tBlock No.");
        for (int i = 0; i < allocation.Length; i++)
        {
            Console.Write(" " + (i + 1) + "\t\t" + processSize[i] + "\t\t");
            if (allocation[i] != -1)
                Console.Write(allocation[i] + 1);
            else
                Console.Write("Not Allocation");
            Console.WriteLine();
        }
    }
}
