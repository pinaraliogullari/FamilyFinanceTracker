import React from 'react';

export default function About() {
  return (
    <div style={{ maxWidth: 700, margin: '2rem auto', padding: '1rem' }}>
        <h1>About Family Finance Tracker</h1>
        <p>
            Family Finance Tracker is a simple tool designed to help families manage their finances efficiently.
            Track your income, expenses, and savings all in one place. Our goal is to make budgeting easy and accessible for everyone.
        </p>
        <h2>Features</h2>
        <ul>
            <li>Easy expense and income tracking</li>
            <li>Visualize your spending habits</li>
            <li>Collaborate with family members</li>
            <li>Secure and private data management</li>
        </ul>
        <h2>Contact</h2>
        <p>
            For feedback or support, please contact us at <a href="mailto:support@familyfinancetracker.com">support@familyfinancetracker.com</a>.
        </p>
    </div>
);
}