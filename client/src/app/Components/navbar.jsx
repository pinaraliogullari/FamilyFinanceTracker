'use client';
import Link from 'next/link';
import { Navbar, Nav, NavDropdown, Container } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';

export default function AppNavbar() {
  return (
    <Navbar bg="light" expand="lg">
      <Container>
        <Navbar.Brand>
          <Link href="/" passHref>Family Finance Tracker</Link>
        </Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="justify-content-end" style={{ width: '100%' }}>
            <Nav.Link>
              <Link href="/" passHref>Home</Link>
            </Nav.Link>
            <Nav.Link>
              <Link href="/dashboard" passHref>Dashboard</Link>
            </Nav.Link>
            <Nav.Link>
              <Link href="/about" passHref>About</Link>
            </Nav.Link>
            <NavDropdown title="İşlemler" id="basic-nav-dropdown">
              <NavDropdown.Item>
                <Link href="/transactions" passHref>İşlem Geçmişi</Link>
              </NavDropdown.Item>
              <NavDropdown.Item>
                <Link href="/transactions/income" passHref>Gelir İşlemleri</Link>
              </NavDropdown.Item>
              <NavDropdown.Item>
                <Link href="/transactions/expense" passHref>Gider İşlemleri</Link>
              </NavDropdown.Item>
            </NavDropdown>
            <NavDropdown title="Profil" id="profile-nav-dropdown">
              <NavDropdown.Item>
                <Link href="/profile" passHref>Hesabım</Link>
              </NavDropdown.Item>
              <NavDropdown.Item>
                <Link href="/profile/records" passHref>Kayıtlarım</Link>
              </NavDropdown.Item>
              <NavDropdown.Divider />
              <NavDropdown.Item onClick={() => console.log('Çıkış')}>
                Çıkış Yap
              </NavDropdown.Item>
            </NavDropdown>
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
}
