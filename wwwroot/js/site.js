function buildProjectCard(project) {
    const col = document.createElement('div');
    col.className = 'col-md-6';

    const card = document.createElement('div');
    card.className = 'project-card d-flex flex-column';

    const title = document.createElement('h3');
    title.textContent = project.title;

    const description = document.createElement('p');
    description.textContent = project.description;

    const badges = document.createElement('div');
    badges.className = 'd-flex flex-wrap gap-2 mb-3';
    project.techStack.split(',').forEach(tech => {
        const badge = document.createElement('span');
        badge.className = 'tech-badge';
        badge.textContent = tech.trim();
        badges.appendChild(badge);
    });

    const link = document.createElement('a');
    link.href = project.gitHubUrl;
    link.target = '_blank';
    link.rel = 'noopener';
    link.className = 'btn btn-outline-light btn-sm mt-auto align-self-start';
    link.textContent = 'View on GitHub';

    card.append(title, description, badges, link);
    col.appendChild(card);
    return col;
}

async function loadProjects() {
    const grid = document.getElementById('projects-grid');
    const status = document.getElementById('projects-status');
    if (!grid || !status) return;

    try {
        const response = await fetch('/Home/Projects');
        if (!response.ok) throw new Error('Request failed: ' + response.status);

        const projects = await response.json();
        if (projects.length === 0) {
            status.textContent = 'No projects yet.';
            return;
        }

        grid.replaceChildren(...projects.map(buildProjectCard));
        status.remove();
    } catch (error) {
        console.error(error);
        status.textContent = 'Could not load projects right now.';
    }
}

document.addEventListener('DOMContentLoaded', loadProjects);