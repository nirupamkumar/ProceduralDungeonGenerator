pipeline {
    agent any

    environment {
        // Define environment variables
        UNITY_PATH = "C:/Program Files/Unity/Hub/Editor/2020.3.9f1/Editor/Unity.exe" // Update this path as per your Unity installation
        PROJECT_PATH = "${WORKSPACE}"
        BUILD_METHOD = "BuildScript.BuildProject"
    }

    stages {
        stage('Checkout') {
            steps {
                // Checkout source code from your repository
                git 'https://github.com/your-repo/your-project.git' // Replace with your repository URL
            }
        }
        
        stage('Build') {
            steps {
                // Run Unity build command
                bat "\"${UNITY_PATH}\" -quit -batchmode -projectPath \"${PROJECT_PATH}\" -executeMethod \"${BUILD_METHOD}\""
            }
        }
    }

    post {
        always {
            // Archive the build artifacts
            archiveArtifacts artifacts: 'D:/Builds/**', allowEmptyArchive: true
        }
    }
}
