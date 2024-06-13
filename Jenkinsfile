pipeline 
{
    agent any

    environment 
    {
        // Define environment variables
        UNITY_PATH = "D:/Unity Hub/Editor/2022.3.14f1/Editor/Unity.exe"
        PROJECT_PATH = "${WORKSPACE}"
        BUILD_METHOD = "BuildScript.BuildProject"
    }

    stages 
    {
        stage('Checkout') 
        {
            steps 
            {
                // Checkout source code from your repository
                git 'https://github.com/your-repo/your-project.git' // Replace with your repository URL
            }
        }
        
        stage('Build') 
        {
            steps 
            {
                // Run Unity build command
                bat "\"${UNITY_PATH}\" -quit -batchmode -projectPath \"${PROJECT_PATH}\" -executeMethod \"${BUILD_METHOD}\""
            }
        }
    }

    post 
    {
        always 
        {
            // Archive the build artifacts
            archiveArtifacts artifacts: 'D:/ProjectBuilds/**', allowEmptyArchive: true
        }
    }
}
