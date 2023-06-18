#pragma once
#include <math.h>
#include "deque.h"

#ifdef MODELLIB2_EXPORTS
#define MODELLIB2_API __declspec(dllexport)
#else
#define MODELLIB2_API 
#endif

typedef double (*F_1ARG)(double);
typedef double (*F_2ARG)(double, double);

#define INC_F_1ARG \
  F_1ARG f_1arg[] = {c_usub, cos, sin, tan, acos, asin, atan, sqrt, log, log10}

#define INC_F_2ARG F_2ARG f_2arg[] = {c_add, c_sub, c_mul, c_div, fmod, pow}

extern "C" MODELLIB2_API double calculation(Deque * rpn, double x);

bool l_get_number_f(lexeme_t* lexeme, double* value);
bool l_get_operation_f(lexeme_t* lexeme, int* value);
int l_get_type_f(lexeme_t* lexeme);
double c_add(double a, double b);
double c_sub(double a, double b);
double c_mul(double a, double b);
double c_div(double a, double b);
double c_usub(double a);
