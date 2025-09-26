// Import required packages
const express = require('express');
const bodyParser = require('body-parser');
const path = require('path');

// Initialize the Express app
const app = express();
const port = 4200;

app.use(express.static(path.join(__dirname, '../../dist')));

app.get('*', (req, res) => {
  res.sendFile(path.join(__dirname, '../../dist/index.html'));
});

// Middleware to parse JSON bodies
app.use(bodyParser.json());

// Start the server
app.listen(port, () => {
    console.log(`Server is running on http://localhost:${port}`);
});