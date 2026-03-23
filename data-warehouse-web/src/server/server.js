// Import required packages
const express = require('express');
const bodyParser = require('body-parser');
const path = require('path');

// Initialize the Express app
const app = express();
const port = 4200;

// Localhost
// app.use(express.static(path.join(__dirname, '../../dist')));

// app.get('*', (req, res) => {
//   res.sendFile(path.join(__dirname, '../../dist/index.html'));
// });

// for synology (in container)
app.use(express.static(path.join(__dirname, 'wwwroot')));

app.get('*', (req, res) => {
  res.sendFile(path.join(__dirname, 'wwwroot', 'index.html'));
  console.log(`Frontend running at http://0.0.0.0:${port}`);
});


// Middleware to parse JSON bodies
app.use(bodyParser.json());

// Start the server
app.listen(port, '0.0.0.0', () => {
    console.log(`Server is running on http://localhost:${port}`);
});