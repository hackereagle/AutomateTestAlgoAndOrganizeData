#include <iostream>

#define PRINT_STEP_TIME(STEP, ELAPSED_TIME_MS) std::cout << STEP << " spend " << ELAPSED_TIME_MS << " ms" << std::endl;

int main(int argc, char* argv[])
{
    PRINT_STEP_TIME("Step1", 10);
    PRINT_STEP_TIME("Step2", 20);
    PRINT_STEP_TIME("Step3", 30);

    getchar();

    return EXIT_SUCCESS;
}