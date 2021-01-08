#include <stdio.h>
#include <time.h>

void resolveNumberToPrimeFactors(int number)
{
	printf("Prime factors of %d: ", number);
	
	while (number % 2 == 0) 
	{
		printf("%d", 2);
		number /= 2;
		
		if (number >= 2) 
		{
			printf(", ");
		}
	}
	
	int factor = 3;
	
	while (factor * factor <= number) 
	{
		if (number % factor == 0) 
		{
			printf("%d", factor);
			number /= factor;
			
			if (number >= factor) 
			{
				printf(", ");
			}
		}
		else 
		{
			factor += 2;
		}
	}
	
	if (number > 1) 
	{
		printf("%d", number);
	}
	
	printf("\n");
}

int main() 
{
    // ---------- Test ---------- 
	#define BILLION  1000000000.0

	struct timespec start, stop;
	clock_gettime(CLOCK_REALTIME, &start);

	resolveNumberToPrimeFactors(10); 		// => Prime factors of 10: 2, 5
	resolveNumberToPrimeFactors(16); 		// => Prime factors of 16: 2, 2, 2, 2
    resolveNumberToPrimeFactors(21); 		// => Prime factors of 21: 3, 7
    resolveNumberToPrimeFactors(25); 		// => Prime factors of 25: 5, 5
    resolveNumberToPrimeFactors(20); 		// => Prime factors of 20: 2, 2, 5
    resolveNumberToPrimeFactors(15); 		// => Prime factors of 15: 3, 5
    resolveNumberToPrimeFactors(1564852); 	// => Prime factors of 1564852: 2, 2, 67, 5839
    resolveNumberToPrimeFactors(68459237); 	// => Prime factors of 68459237: 7, 11, 889081
	
	clock_gettime(CLOCK_REALTIME, &stop);

	double timeSpent = (stop.tv_sec - start.tv_sec) + (stop.tv_nsec - start.tv_nsec) / BILLION;
	printf("\nRuntime: %.7f seconds\n", timeSpent);
	
	return 0;
}
