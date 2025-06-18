// DevTrack Mobile Navigation
let mobileMenuOpen = false;

// Initialize mobile navigation
function initializeMobileNavigation() {
    // Handle escape key to close mobile menu
    document.addEventListener('keydown', function(e) {
        if (e.key === 'Escape' && mobileMenuOpen) {
            closeMobileMenu();
        }
    });

    // Handle window resize
    window.addEventListener('resize', function() {
        if (window.innerWidth >= 992) {
            closeMobileMenu();
        }
    });
}

// Close mobile menu
function closeMobileMenu() {
    const sidebar = document.querySelector('.sidebar');
    const overlay = document.querySelector('.mobile-overlay');
    
    if (sidebar) {
        sidebar.classList.remove('show');
    }
    if (overlay) {
        overlay.classList.remove('show');
    }
    
    mobileMenuOpen = false;
    
    // Trigger Blazor component update
    if (window.DotNet) {
        DotNet.invokeMethodAsync('DevTrack', 'CloseMobileMenu');
    }
}

// Toggle mobile menu
function toggleMobileMenu() {
    const sidebar = document.querySelector('.sidebar');
    const overlay = document.querySelector('.mobile-overlay');
    
    if (sidebar && overlay) {
        const isShowing = sidebar.classList.contains('show');
        
        if (isShowing) {
            sidebar.classList.remove('show');
            overlay.classList.remove('show');
            mobileMenuOpen = false;
        } else {
            sidebar.classList.add('show');
            overlay.classList.add('show');
            mobileMenuOpen = true;
        }
    }
}

// Auto-close menu when clicking nav links on mobile
document.addEventListener('DOMContentLoaded', function() {
    const navLinks = document.querySelectorAll('.nav-menu .nav-link');
    
    navLinks.forEach(link => {
        link.addEventListener('click', function() {
            if (window.innerWidth < 992 && mobileMenuOpen) {
                setTimeout(closeMobileMenu, 150); // Small delay for better UX
            }
        });
    });
});

// Prevent body scroll when mobile menu is open
function preventBodyScroll() {
    if (mobileMenuOpen) {
        document.body.style.overflow = 'hidden';
    } else {
        document.body.style.overflow = '';
    }
}

// Initialize when page loads
document.addEventListener('DOMContentLoaded', initializeMobileNavigation); 