#include "Indexer.h"
int main() 
{
    double* array = new double[10]{ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    Indexer a = Indexer(array, 5, 8, 10);
    return 0;
}
