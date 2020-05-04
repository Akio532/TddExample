#pragma once
class Indexer
{
private:
	double* array;
	int firstIndex, lastIndex;
public:
	Indexer(double* array, int arrayLength, int firstIndex, int length);
	int Length();
	double& operator[] (const int index);
};
