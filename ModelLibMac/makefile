GCC=g++
CPPFLAGS=-lstdc++ -std=c++17
MODEL=main.cpp RPN.cpp calc.cpp deque.cpp
LIBFLAGS=--verbose -dynamiclib

dylib:
	$(GCC) $(CPPFLAGS) $(LIBFLAGS) $(MODEL) -o libSmC.dylib

clean:
	rm -rf *.o *.dylib