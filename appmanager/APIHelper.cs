using System.Collections.Generic;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager) { }

        public void CreateNewIssue(AccountData account, ProjectData project, IssueData issueData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData
            {
                summary = issueData.Summary,
                description = issueData.Description,
                category = issueData.Category,
                project = new Mantis.ObjectRef()
            };
            issue.project.id = project.Id;
            client.mc_issue_add(account.Name, account.Password, issue);
        }

        public List<ProjectData> GetProjectList(AccountData account)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData[] mantisProjectList = client.mc_projects_get_user_accessible(account.Name,
                account.Password);
            List<ProjectData> projectList = new List<ProjectData>();
            for (int i = 0; i < mantisProjectList.Length; i++)
            {
                projectList.Add(new ProjectData()
                {
                    Id = mantisProjectList[i].id,
                    Name = mantisProjectList[i].name
                });
            }
            return new List<ProjectData>(projectList);
        }

        public void Create(AccountData account, ProjectData project)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData newProject = new Mantis.ProjectData
            {
                name = project.Name
            };
            client.mc_project_add(account.Name, account.Password, newProject);
        }

        public void Remove(AccountData account, int index)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData[] mantisProjectList = client.mc_projects_get_user_accessible(account.Name,
                account.Password);
            client.mc_project_delete(account.Name, account.Password, mantisProjectList[index].id);
        }

        public bool IsAnyProjectPresent(AccountData account)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData[] mantisProjectList = client.mc_projects_get_user_accessible(account.Name,
                account.Password);
            return mantisProjectList.Length > 0;
        }
    }
}