#include "SystemLinearEquation.h"
#include <iostream>
#include <clocale>
using namespace std;

LinearEquation& SystemLinearEquation::operator[](int index)
{
	setlocale(0, "");
	if (index >= 0 && index < system.size())
		return system[index];
	else 
		throw out_of_range("Вне диапазона");
}
void SystemLinearEquation::add(LinearEquation& a)
{
	if (a.size() == n + 1)
		system.push_back(a);
	else throw invalid_argument("Неверный аргумент");
}
int SystemLinearEquation::size()
{
	return system.size();
}

void SystemLinearEquation::steppingUp()
{
	int x;
	for (int i = 0; i < size(); i++)
	{
		x = i;
		if (system[i][x] == 0)
		{
			while (system[i][x] == 0 && x < n) x++;
			i = 1;
			while ((i + i) < size() && system[i + i][x] == 0) i++;
			if ((i + i) == size())
				return;
			swap(system[i], system[i + i]);
		}
		for (int j = i + 1; j < size(); j++)
		{
			LinearEquation tmp1 = system[j] * system[i][x];
			LinearEquation tmp2 = system[i] * system[j][x];
			system[j] = tmp1 - tmp2;
		}
	}
}
void SystemLinearEquation::remove()
{
	system.pop_back();
}
vector<double> SystemLinearEquation::solveSystem()
{
	while (system[size() - 1].isNull())
		system.pop_back();
	if (system[size() - 1])
	{
		if (size() == n)
		{
			vector<double> solve(n);
			for (int i = size() - 1; i >= 0; i--)
			{
				solve[i] = system[i][n];
				for (int j = i + 1; j < n; j++)
				{
					solve[i] -= system[i][j] * solve[j];
				}
				solve[i] /= system[i][i];
			}
			return solve;
		}
		else throw invalid_argument("Система имеет бесконечно много решений");
	}
	else throw invalid_argument("Система не имеет решений");
}
SystemLinearEquation::operator std::string()
{
	string res = "";
	for (int i = 0; i < size(); i++)
		res += (string)system[i] + '\n';
	return res;
}
