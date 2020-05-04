#include"SystemLinearEquation.h"
#include"LinearEquation.h"
#include <iostream>
#include<vector>
#include<ctime>

using namespace std;

int main()
{
	srand(time(NULL));
	int temp = 5;
	SystemLinearEquation s(temp);
	LinearEquation seq1(temp);
	LinearEquation seq2(temp);
	LinearEquation seq3(temp);
	LinearEquation seq4(temp);
	LinearEquation seq5(temp);
	seq1.random_initialization();
	seq2.random_initialization();
	seq3.random_initialization();
	seq4.random_initialization();
	seq5.random_initialization();
	s.add(seq1);
	s.add(seq2);
	s.add(seq3);
	s.add(seq4);
	s.add(seq5);
	cout << "1: " << endl;
	cout << (string)s << endl;
	s.steppingUp();
	cout << "2: " << endl;
	cout << (string)s << endl;
	vector<double> solve = s.solveSystem();
	cout << "Answer: ";
	for (int i = 0; i < solve.size(); i++)
		cout << solve[i] << "   ";
}

